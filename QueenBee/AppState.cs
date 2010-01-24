using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Nanook.QueenBee
{
    internal static class AppState
    {
        public static string InputFormat { get; set; }
        public static string PakFilename { get; set; }
        public static string PabFilename { get; set; }
        public static string DebugFilename { get; set; }
        public static bool Backup { get; set; }
        public static string LastQbReplacePath { get; set; }
        public static string LastQbExtractPath { get; set; }
        public static string QbListColPositions { get; set; }
        public static string QbListColWidths { get; set; }
        public static string PakListColPositions { get; set; }
        public static string PakListColWidths { get; set; }
        public static string PakListSort { get; set; }
        public static string SearchListColPositions { get; set; }
        public static string SearchListColWidths { get; set; }
        public static string SearchListSort { get; set; }
        public static string WindowInfo { get; set; }
        public static float QbSplitterPosition { get; set; }
        public static float PakSplitterPosition { get; set; }
        public static float SearchSplitterPosition { get; set; }
        public static int ScriptActiveTab { get; set; }
        public static string LastScriptPath { get; set; }
        public static string LastArrayPath { get; set; }

        public static void LoadPakListColInfo(ListView lv, string widths, string positions, string sort)
        {
            loadListViewInfo(lv, widths, positions, sort);
            if (widths.Length != 0)
                PakListColWidths = widths;
            if (positions.Length != 0)
                PakListColPositions = positions;
            if (sort.Length != 0)
                PakListSort = sort;
        }

        public static void LoadSearchListColInfo(ListView lv, string widths, string positions, string sort)
        {
            loadListViewInfo(lv, widths, positions, sort);
            if (widths.Length != 0)
                SearchListColWidths = widths;
            if (positions.Length != 0)
                SearchListColPositions = positions;
            if (sort.Length != 0)
                SearchListSort = sort;
        }

        public static void LoadQbListColInfo(ListView lv, string widths, string positions)
        {
            loadListViewInfo(lv, widths, positions, string.Empty);
            if (widths.Length != 0)
                QbListColWidths = widths;
            if (positions.Length != 0)
                QbListColPositions = positions;
        }

        public static void SavePakListColInfo(ListView lv)
        {
            string cp, cw, cs;
            saveListViewInfo(lv, out cp, out cw, out cs);
            PakListColPositions = cp;
            PakListColWidths = cw;
            PakListSort = cs;
        }

        public static void SaveSearchListColInfo(ListView lv)
        {
            string cp, cw, cs;
            saveListViewInfo(lv, out cp, out cw, out cs);
            SearchListColPositions = cp;
            SearchListColWidths = cw;
            SearchListSort = cs;
        }

        public static void SaveQbListColInfo(ListView lv)
        {
            string cp, cw, cs;
            saveListViewInfo(lv, out cp, out cw, out cs);
            QbListColPositions = cp;
            QbListColWidths = cw;
        }

        public static void SavePakSplitterInfo(SplitContainer sp)
        {
            float p;
            saveSplitterInfo(sp, out p);
            PakSplitterPosition = p;
        }

        public static void SaveSearchSplitterInfo(SplitContainer sp)
        {
            float p;
            saveSplitterInfo(sp, out p);
            SearchSplitterPosition = p;
        }

        public static void SaveQbSplitterInfo(SplitContainer sp)
        {
            float p;
            saveSplitterInfo(sp, out p);
            QbSplitterPosition = p;
        }

        public static void LoadPakSplitterPosition(SplitContainer sp, string position)
        {
            float f;
            if (position.Length != 0)
            {
                f = float.Parse(position);
                loadSplitterPosition(sp, f);
            }
            else
                saveSplitterInfo(sp, out f);

            PakSplitterPosition = f;
        }

        public static void LoadSearchSplitterPosition(SplitContainer sp, string position)
        {
            float f;
            if (position.Length != 0)
            {
                f = float.Parse(position);
                loadSplitterPosition(sp, f);
            }
            else
                saveSplitterInfo(sp, out f);

            SearchSplitterPosition = f;
        }

        public static void LoadQbSplitterPosition(SplitContainer sp, string position)
        {
            float f;
            if (position.Length != 0)
            {
                f = float.Parse(position);
                loadSplitterPosition(sp, f);
            }
            else
                saveSplitterInfo(sp, out f);

            QbSplitterPosition = f;
        }

        public static void SaveWindowInfo(Form win)
        {
            if (win.WindowState == FormWindowState.Normal)
                WindowInfo = string.Format("{0},{1},{2},{3},{4}", win.Location.X, win.Location.Y, win.Size.Width, win.Size.Height, (int)(win.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : win.WindowState));
            else
            {
                string[] s = WindowInfo.Split(',');
                s[4] = ((int)(win.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : win.WindowState)).ToString();
                WindowInfo = string.Join(",", s);
            }
        }

        public static void LoadWindowInfo(Form win, string settings)
        {
            if (settings.Length != 0)
            {
                WindowInfo = settings;
                string[] wi = settings.Split(',');
                win.Location = new Point(int.Parse(wi[0]), int.Parse(wi[1]));
                win.Size = new Size(int.Parse(wi[2]), int.Parse(wi[3]));
                win.WindowState = (FormWindowState)int.Parse(wi[4]);
                win.Refresh();
            }
            else
            {
                win.WindowState = FormWindowState.Normal;
                win.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - win.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - win.Height) / 2);
            }
        }


        private static void loadSplitterPosition(SplitContainer sp, float position)
        {
            sp.SplitterDistance = (int)((position / 100F) * sp.Width);
        }

        private static void saveSplitterInfo(SplitContainer sp, out float position)
        {
            position = (((float)sp.SplitterDistance / (float)sp.Width) * 100F);
        }

        private static void saveListViewInfo(ListView lv, out string colPos, out string colWidths, out string colSort)
        {
            string[] colP = new string[lv.Columns.Count];
            string[] colW = new string[lv.Columns.Count];
            foreach (ColumnHeader ch in lv.Columns)
            {
                colP[ch.DisplayIndex] = ch.Index.ToString();
                colW[ch.DisplayIndex] = ch.Width.ToString();
            }
            colPos = string.Join(",", colP);
            colWidths = string.Join(",", colW);

            if (lv.ListViewItemSorter != null)
                colSort = string.Format("{0},{1}", ((ListViewColumnSorter)lv.ListViewItemSorter).SortColumn.ToString(), ((int)((ListViewColumnSorter)lv.ListViewItemSorter).Order).ToString());
            else
                colSort = string.Empty;

        }

        private static void loadListViewInfo(ListView lv, string widths, string positions, string sort)
        {
            if (widths.Length != 0 && positions.Length != 0)
            {

                string[] w = widths.Split(',');
                string[] p = positions.Split(',');
                if (p.Length == lv.Columns.Count && w.Length == lv.Columns.Count)
                {
                    ColumnHeader ch;
                    for (int i = 0; i < lv.Columns.Count; i++)
                    {
                        ch = lv.Columns[int.Parse(p[i])];
                        ch.DisplayIndex = i;
                        ch.Width = int.Parse(w[i]);
                    }
                }
            }

            if (sort.Length != 0 && lv.ListViewItemSorter != null)
            {
                string[] srt = sort.Split(',');
                ListViewColumnSorter lvs = (ListViewColumnSorter)lv.ListViewItemSorter;
                lvs.SortColumn = int.Parse(srt[0]);
                lvs.Order = (SortOrder)int.Parse(srt[1]);
                lvs.Numeric = (lv.Columns[lvs.SortColumn].Text == "Length");
            }
        }
    }
}
