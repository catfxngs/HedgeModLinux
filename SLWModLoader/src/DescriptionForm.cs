﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLWModLoader
{
    public partial class DescriptionForm : Form
    {

        private string authorUrl;

        public DescriptionForm(string description, string title, string author, string date, string url, string version, string authorUrl)
        {
            InitializeComponent();
            authorLbl.LinkArea = new LinkArea(0, 0);
            descriptionLbl.Text = description.Replace("\\n", "\n");
            titleLbl.Text = title + " v"+ version;
            authorLbl.Text = $"Made by {author} on {date}";
            this.authorUrl = authorUrl;
            if (url != null && url.Length > 0)
                titleLbl.Links.Add(new LinkLabel.Link(0, title.Length, url));
            if (authorUrl.Length > 0)
            {
                int i = 0;
                var autherSplit = author.Split(new string[] { " & " }, StringSplitOptions.None);
                var authorUrlSplit = authorUrl.Split(new string[] { " & " }, StringSplitOptions.None);
                foreach (string str in autherSplit)
                {
                    authorLbl.Links.Add(new LinkLabel.Link(8 + i, str.Length, authorUrlSplit[Array.IndexOf(autherSplit, str)]));
                    i += str.Length + 3;
                }
            }
        }

        public DescriptionForm(Mod mod)
        : this(mod.Description, mod.Title, mod.Author, mod.Date, mod.Url, mod.Version, mod.AuthorUrl)
        {
            #region Nothing to see here
            IniGroup Desc = mod.GetIniFile()["Desc"];
            if (Desc.ContainsParameter("BackgroundImage"))
            {
                try
                {
                    BackgroundImage = Bitmap.FromFile(Path.Combine(mod.RootDirectory, Desc["BackgroundImage"]));
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch { }
            }

            if (Desc.ContainsParameter("BackgroundImageCount"))
            {
                try
                {
                    var rand = new Random();
                    BackgroundImage = Bitmap.FromFile(Path.Combine(mod.RootDirectory, Desc["BackgroundImage" + rand.Next((int)Desc["BackgroundImageCount", typeof(int)])]));
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch { }
            }

            if (Desc.ContainsParameter("TextColor"))
            {
                try
                {
                    descriptionLbl.ForeColor = Color.FromArgb(
                        Convert.ToInt32(Desc["TextColor"].Split(',')[0]),
                        Convert.ToInt32(Desc["TextColor"].Split(',')[1]),
                        Convert.ToInt32(Desc["TextColor"].Split(',')[2]));
                }
                catch { }
            }

            if (Desc.ContainsParameter("TextFont"))
            {
                try
                {
                    descriptionLbl.Font = new Font(Desc["TextFont"], 8.25f);
                }
                catch { }
            }

            if (Desc.ContainsParameter("TextSize"))
            {
                try
                {
                    descriptionLbl.Font = new Font(descriptionLbl.Font.FontFamily, float.Parse(Desc["TextSize"]));
                }
                catch { }
            }

            if (Desc.ContainsParameter("HeaderColor"))
            {
                try
                {
                    titleLbl.LinkColor = titleLbl.ForeColor =
                        authorLbl.LinkColor = authorLbl.ForeColor =
                        Color.FromArgb(Convert.ToInt32(Desc["HeaderColor"].Split(',')[0]),
                                       Convert.ToInt32(Desc["HeaderColor"].Split(',')[1]),
                                       Convert.ToInt32(Desc["HeaderColor"].Split(',')[2]));
                }
                catch { }

            }

            if (Desc.ContainsParameter("HeaderFont"))
            {
                try
                {
                    titleLbl.Font = new Font(Desc["HeaderFont"], titleLbl.Font.Size);
                }
                catch { }
            }

            if(Desc.ContainsParameter("HeaderSize"))
            {
                try
                {
                    titleLbl.Font = new Font(titleLbl.Font.FontFamily, float.Parse(Desc["HeaderSize"]));
                    authorLbl.Location = new Point(authorLbl.Location.X, titleLbl.Location.Y + ((int)float.Parse(Desc["HeaderSize"])) + 23);
                    descriptionLbl.Location = new Point(descriptionLbl.Location.X, descriptionLbl.Location.Y + 23);
                }
                catch { }
            }

            if (Desc.ContainsParameter("AuthorColor"))
            {
                try
                {
                    authorLbl.LinkColor = authorLbl.ForeColor =
                        Color.FromArgb(Convert.ToInt32(Desc["HeaderColor"].Split(',')[0]),
                                       Convert.ToInt32(Desc["HeaderColor"].Split(',')[1]),
                                       Convert.ToInt32(Desc["HeaderColor"].Split(',')[2]));
                }
                catch { }

            }

            if (Desc.ContainsParameter("AuthorFont"))
            {
                try
                {
                    authorLbl.Font = new Font(Desc["AuthorFont"], authorLbl.Font.Size);
                }
                catch { }
            }

            if (Desc.ContainsParameter("AuthorSize"))
            {
                try
                {
                    authorLbl.Font = new Font(authorLbl.Font.FontFamily, float.Parse(Desc["AuthorSize"]));
                    descriptionLbl.Location = new Point(descriptionLbl.Location.X, descriptionLbl.Location.Y +
                        (int)float.Parse(Desc["AuthorSize"]));
                }
                catch { }
            }
            #endregion
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (e.Link.LinkData == null || (e.Link.LinkData as string).Length == 0) return;
                if (Program.isURL(e.Link.LinkData as string))
                    Process.Start(e.Link.LinkData as string);
            }
            catch { }
        }
    }
}
