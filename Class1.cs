//namespace DynamicGeometry
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Collections.ObjectModel;
//    using System.Linq;
//    using System.Text;
//    //using System.Windows.Controls;
//    //using System.Windows.Media;
//    using System.Xml.Linq;

//    using netDxf;
//    using netDxf.Blocks;
//    using netDxf.Entities;

//    public class DXFDrawingDeserializer
//    {
//        #region Fields

//        DxfDocument doc;
//        Drawing drawing;

//        #endregion Fields

//        #region Methods

//        public Drawing ReadDrawing(string dxfFileName, Canvas canvas)
//        {
//            doc = new DxfDocument();
//            doc.Load(dxfFileName);

//            drawing = new Drawing(canvas);

//            ReadLines();
//            ReadPolylines();
//            ReadArcs();
//            ReadCircles();
//            ReadInserts();

//            drawing.Recalculate();
//            return drawing;
//        }

//        netDxf.Entities.Polyline CastPolyline(IPolyline item)
//        {
//            netDxf.Entities.Polyline polyline = null;
//            if (item is LightWeightPolyline)
//            {
//                polyline = ((LightWeightPolyline)item).ToPolyline();
//            }
//            else if (item is Polyline)
//            {
//                polyline = (netDxf.Entities.Polyline)item;
//            }
//            else
//            {
//                polyline = null;
//            }
//            return polyline;
//        }

//        FreePoint CreateHiddenPoint(double x, double y)
//        {
//            return new FreePoint()
//            {
//                Drawing = drawing,
//                X = x,
//                Y = y,
//                Visible = false
//            };
//        }

//        Segment CreateSegment(IPoint p1, IPoint p2)
//        {
//            return Factory.CreateSegment(drawing, new[] { p1, p2 });
//        }

//        void ReadArc(netDxf.Entities.Arc arc, double x, double y)
//        {
//            // TODO :
//        }

//        void ReadArcs()
//        {
//            foreach (var item in doc.Arcs)
//            {
//                ReadArc(item, 0, 0);
//            }
//        }

//        void ReadCircle(netDxf.Entities.Circle circle, double x, double y)
//        {
//            var figures = new List<IFigure>();

//            figures.Add(CreateHiddenPoint(circle.Center.X + x, circle.Center.Y + y));
//            figures.Add(CreateHiddenPoint(circle.Center.X + x + circle.Radius, circle.Center.Y + y));

//            var figure = Factory.CreateCircleByRadius(drawing, figures);
//        }

//        void ReadCircles()
//        {
//            foreach (var item in doc.Circles)
//            {
//                ReadCircle(item, 0, 0);
//            }
//        }

//        void ReadInsert(netDxf.Entities.Insert insert)
//        {
//            List<netDxf.Entities.IEntityObject> entities = insert.Block.Entities;
//            netDxf.Entities.IEntityObject entity = null;

//            for (int index = 1; index < entities.Count; index++)
//            {
//                entity = entities[index];

//                if (entity is Line)
//                    ReadLine((Line)entity, insert.InsertionPoint.X, insert.InsertionPoint.Y);
//                else if (entity is netDxf.Entities.Arc)
//                    ReadArc((netDxf.Entities.Arc)entity, insert.InsertionPoint.X, insert.InsertionPoint.Y);
//                else if (entity is netDxf.Entities.Circle)
//                    ReadCircle((netDxf.Entities.Circle)entity, insert.InsertionPoint.X, insert.InsertionPoint.Y);
//                else if (entity is IPolyline)
//                {
//                    netDxf.Entities.Polyline polyline = CastPolyline((IPolyline)entity);
//                    if (polyline != null)
//                    {
//                        ReadPolyline(polyline.Vertexes, polyline.IsClosed, 0, 0);
//                    }
//                }

//            }
//        }

//        void ReadInserts()
//        {
//            foreach (var item in doc.Inserts)
//            {
//                ReadInsert(item);
//            }
//        }

//        void ReadLine(Line line, double x, double y)
//        {
//            var point1 = CreateHiddenPoint(line.StartPoint.X + x, line.StartPoint.Y + y);
//            var point2 = CreateHiddenPoint(line.EndPoint.X + x, line.EndPoint.Y + y);
//            var segment = CreateSegment(point1, point2);
//            Actions.Add(drawing, segment);
//        }

//        void ReadLines()
//        {
//            foreach (var line in doc.Lines)
//            {
//                ReadLine(line, 0, 0);
//            }
//        }

//        void ReadPolyline(IList<PolylineVertex> vertices, bool isClosed, double x, double y)
//        {
//            IPoint firstPoint = null;
//            IPoint previousPoint = null;
//            var figures = new List<IFigure>();
//            var segments = new List<IFigure>();

//            foreach (var vertex in vertices)
//            {
//                var point = CreateHiddenPoint(vertex.Location.X + x, vertex.Location.Y + y);
//                if (firstPoint == null)
//                {
//                    firstPoint = point;
//                }
//                if (previousPoint != null)
//                {
//                    var segment = CreateSegment(previousPoint, point);
//                    figures.Add(segment);
//                    segments.Add(segment);
//                }
//                previousPoint = point;
//                figures.Add(point);
//            }
//            if (previousPoint != null && isClosed)
//            {
//                var segment = CreateSegment(previousPoint, firstPoint);
//                figures.Add(segment);
//                segments.Add(segment);

//                var polygon = Factory.CreatePolygon(drawing, figures);
//                Actions.Add(drawing, polygon);
//            }

//            Actions.AddMany(drawing, segments.ToArray());
//        }

//        void ReadPolylines()
//        {
//            foreach (var item in doc.Polylines)
//            {
//                netDxf.Entities.Polyline polyline = CastPolyline(item);
//                if (polyline != null)
//                {
//                    ReadPolyline(polyline.Vertexes, polyline.IsClosed, 0, 0);
//                }
//            }
//        }

//        #endregion Methods
//    }
//}
using Autodesk.AutoCAD.Runtime;

using Autodesk.AutoCAD.ApplicationServices;

using Autodesk.AutoCAD.DatabaseServices;

using Autodesk.AutoCAD.EditorInput;

using Autodesk.AutoCAD.Geometry;

using Autodesk.AutoCAD.PlottingServices;
namespace PlottingApplication

{

    public class PlottingCommands

    {

        [CommandMethod("simplot")]

        static public void SimplePlot()

        {

            Document doc =

              Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Database db = doc.Database;


            Transaction tr =

              db.TransactionManager.StartTransaction();

            using (tr)

            {

                // We'll be plotting the current layout


                BlockTableRecord btr =

                  (BlockTableRecord)tr.GetObject(

                    db.CurrentSpaceId,

                    OpenMode.ForRead

                  );

                Layout lo =

                  (Layout)tr.GetObject(

                    btr.LayoutId,

                    OpenMode.ForRead

                  );


                // We need a PlotInfo object

                // linked to the layout


                PlotInfo pi = new PlotInfo();

                pi.Layout = btr.LayoutId;


                // We need a PlotSettings object

                // based on the layout settings

                // which we then customize


                PlotSettings ps =

                  new PlotSettings(lo.ModelType);

                ps.CopyFrom(lo);


                // The PlotSettingsValidator helps

                // create a valid PlotSettings object


                PlotSettingsValidator psv =

                  PlotSettingsValidator.Current;


                // We'll plot the extents, centered and

                // scaled to fit


                psv.SetPlotType(

                  ps,

                  Autodesk.AutoCAD.DatabaseServices.PlotType.Extents

                );

                psv.SetUseStandardScale(ps, true);

                psv.SetStdScaleType(ps, StdScaleType.ScaleToFit);

                psv.SetPlotCentered(ps, true);


                // We'll use the standard DWF PC3, as

                // for today we're just plotting to file


                psv.SetPlotConfigurationName(

                  ps,

                  "DWF6 ePlot.pc3",

                  "ANSI_A_(8.50_x_11.00_Inches)"

                );


                // We need to link the PlotInfo to the

                // PlotSettings and then validate it


                pi.OverrideSettings = ps;

                PlotInfoValidator piv =

                  new PlotInfoValidator();

                piv.MediaMatchingPolicy =

                  MatchingPolicy.MatchEnabled;

                piv.Validate(pi);


                // A PlotEngine does the actual plotting

                // (can also create one for Preview)


                if (PlotFactory.ProcessPlotState ==

                    ProcessPlotState.NotPlotting)

                {

                    PlotEngine pe =

                      PlotFactory.CreatePublishEngine();

                    using (pe)

                    {

                        // Create a Progress Dialog to provide info

                        // and allow thej user to cancel


                        PlotProgressDialog ppd =

                          new PlotProgressDialog(false, 1, true);

                        using (ppd)

                        {

                            ppd.set_PlotMsgString(

                              PlotMessageIndex.DialogTitle,

                              "Custom Plot Progress"

                            );

                            ppd.set_PlotMsgString(

                              PlotMessageIndex.CancelJobButtonMessage,

                              "Cancel Job"

                            );

                            ppd.set_PlotMsgString(

                              PlotMessageIndex.CancelSheetButtonMessage,

                              "Cancel Sheet"

                            );

                            ppd.set_PlotMsgString(

                              PlotMessageIndex.SheetSetProgressCaption,

                              "Sheet Set Progress"

                            );

                            ppd.set_PlotMsgString(

                              PlotMessageIndex.SheetProgressCaption,

                              "Sheet Progress"

                            );

                            ppd.LowerPlotProgressRange = 0;

                            ppd.UpperPlotProgressRange = 100;

                            ppd.PlotProgressPos = 0;


                            // Let's start the plot, at last


                            ppd.OnBeginPlot();

                            ppd.IsVisible = true;

                            pe.BeginPlot(ppd, null);


                            // We'll be plotting a single document


                            pe.BeginDocument(

                              pi,

                              doc.Name,

                              null,

                              1,

                              true, // Let's plot to file

                              "c:\\test-output"

                            );


                            // Which contains a single sheet


                            ppd.OnBeginSheet();


                            ppd.LowerSheetProgressRange = 0;

                            ppd.UpperSheetProgressRange = 100;

                            ppd.SheetProgressPos = 0;


                            PlotPageInfo ppi = new PlotPageInfo();

                            pe.BeginPage(

                              ppi,

                              pi,

                              true,

                              null

                            );

                            pe.BeginGenerateGraphics(null);

                            pe.EndGenerateGraphics(null);


                            // Finish the sheet

                            pe.EndPage(null);

                            ppd.SheetProgressPos = 100;

                            ppd.OnEndSheet();


                            // Finish the document


                            pe.EndDocument(null);


                            // And finish the plot


                            ppd.PlotProgressPos = 100;

                            ppd.OnEndPlot();

                            pe.EndPlot(null);

                        }

                    }

                }

                else

                {

                    ed.WriteMessage(

                      "\nAnother plot is in progress."

                    );

                }

            }

        }

    }

}