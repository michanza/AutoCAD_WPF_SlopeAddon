using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCAD_WPF_SlopeAddon.ViewModels;
using System.Runtime.CompilerServices;

namespace AutoCAD_WPF_SlopeAddon.Models
{
    public class CustomLine
    {

        public double[] uOrigin = new double[] { 0, 0, 0 };
        public double[] uVector = new double[] { 1000, 0, 0 };


        public void SetVector(double[] vec)
        {
            uVector = vec; 
        }

        public void SetOrigin(double[] vec)
        {
            uOrigin = vec;
        }

        public void DrawLine()

        {
            var acDoc = Application.DocumentManager.MdiActiveDocument;
            var acCurDb = acDoc.Database;
            var ed = acDoc.Editor;

                        
            //Application.ShowAlertDialog("Trying to draw a line...");

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                   OpenMode.ForRead) as BlockTable;
                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acDoc.LockDocument();
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                      OpenMode.ForWrite) as BlockTableRecord;
                // Create a line that starts at Origin and ends at Origin + Vector
                Line acLine = new Line(new Point3d(uOrigin[0], uOrigin[1], uOrigin[2]),
                                             new Point3d(uOrigin[0]+uVector[0], uOrigin[1] + uVector[1], uOrigin[2] + uVector[2]));
                acLine.SetDatabaseDefaults();
                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(acLine);
                acTrans.AddNewlyCreatedDBObject(acLine, true);
                // Save the new object to the database
                acTrans.Commit();
            }


        }

    }
}
