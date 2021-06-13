using UnityEngine;

namespace Rope
{
    public class RopeController : MonoBehaviour
    {
        public GameObject fragmentPrefab;
        public int fragmentCount = 80;
        public Vector3 interval = new Vector3(0f, 0f, 0.25f);
        public Rigidbody anchorPoint1;
        public Rigidbody anchorPoint2;

        GameObject[] fragments;

        float activeFragmentCount;

        float[] xPositions;
        float[] yPositions;
        float[] zPositions;

        CatmullRomSpline splineX;
        CatmullRomSpline splineY;
        CatmullRomSpline splineZ;

        int splineFactor = 4;

        void Start()
        {
            activeFragmentCount = fragmentCount;

            fragments = new GameObject[fragmentCount];

            var position = anchorPoint1.transform.position;

            for (var i = 0; i < fragmentCount; i++)
            {
                fragments[i] = Instantiate(fragmentPrefab, position, Quaternion.identity);
                fragments[i].transform.SetParent(transform);

                var joint = fragments[i].GetComponent<SpringJoint>();
                if (i > 0)
                {
                    joint.connectedBody = fragments[i - 1].GetComponent<Rigidbody>();
                }
                else
                {
                    joint.connectedBody = anchorPoint1;
                }
                
                position += interval;
            }

            fragments[fragmentCount - 1].GetComponent<SpringJoint>().connectedBody = anchorPoint2;
            SpringJoint newJoint = fragments[fragmentCount - 1].AddComponent<SpringJoint>();
            newJoint.connectedBody = fragments[fragmentCount - 2].GetComponent<Rigidbody>();

            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = (fragmentCount - 1) * splineFactor + 1;

            xPositions = new float[fragmentCount];
            yPositions = new float[fragmentCount];
            zPositions = new float[fragmentCount];

            splineX = new CatmullRomSpline(xPositions);
            splineY = new CatmullRomSpline(yPositions);
            splineZ = new CatmullRomSpline(zPositions);
        }

        void Update()
        {
            /*var vy = Input.GetAxisRaw("Vertical") * 20f * Time.deltaTime;
            activeFragmentCount = Mathf.Clamp(activeFragmentCount + vy, 0, fragmentCount);

            for (var i = 0; i < fragmentCount; i++)
            {
                if (i <= fragmentCount - activeFragmentCount)
                {
                    fragments[i].GetComponent<Rigidbody>().position = Vector3.zero;
                    fragments[i].GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    fragments[i].GetComponent<Rigidbody>().isKinematic = false;
                }
            }*/
            
            // TODO: Allow this some time later
        }

        void LateUpdate()
        {
            // Copy rigidbody positions to the line renderer
            var lineRenderer = GetComponent<LineRenderer>();

            // No interpolation
            //for (var i = 0; i < fragmentNum; i++)
            //{
            //    renderer.SetPosition(i, fragments[i].transform.position);
            //}

            for (var i = 0; i < fragmentCount; i++)
            {
                var position = fragments[i].transform.position;
                xPositions[i] = position.x;
                yPositions[i] = position.y;
                zPositions[i] = position.z;
            }

            for (var i = 0; i < (fragmentCount - 1) * splineFactor + 1; i++)
            {
                lineRenderer.SetPosition(i, new Vector3(
                    splineX.GetValue(i / (float) splineFactor),
                    splineY.GetValue(i / (float) splineFactor),
                    splineZ.GetValue(i / (float) splineFactor)));
            }
        }
    }
}
