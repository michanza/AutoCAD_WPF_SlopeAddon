using System;
using System.ComponentModel;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AutoCAD_WPF_SlopeAddon
{
    public class Main
    {
        [CommandMethod("dslope")]
        public static void StartAddon()
        {
            var acDoc = Application.DocumentManager.MdiActiveDocument;
            var acCurDb = acDoc.Database;
            var ed = acDoc.Editor;

            var userWindow = new UserWindow()
            {
                DataContext = new ViewModels.userWindowVM()
            };

            Application.ShowModelessWindow(userWindow);

        }

    }

}


  

