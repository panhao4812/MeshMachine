using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Parameters;
using Rhino.Geometry;
using Plankton;
using PlanktonGh;

namespace remesher
{
    public class SimpleTargetLengthComponent : GH_Component
    {
        public SimpleTargetLengthComponent()
            : base("Simple", "Simple", "Simple Target Length", "Kangaroo", "Mesh")
        {
        }


        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Simple", "S", "Target Length", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Target", "T", "Target Length", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double length = default(double);
            DA.GetData<double>(0, ref length);
            var target = new SimpleTargetLength(length);
            DA.SetData(0, target);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.remesh;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("{d7236440-880d-4f2a-8de2-c56af0b7f2fe}"); }
        }
    }

    public class SimpleTargetLength : ITargetLength
    {
        double _length;

        public SimpleTargetLength(double length)
        {
          this._length = length;
        }

        public double Calculate(PlanktonMesh P, int HalfEdge)
        {
            return this._length;
        }
    }
}
