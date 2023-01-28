using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebScraperV1
{
    public partial class Form1 : Form
    {

        public string enlace = "https://kworb.net/spotify/country/py_daily.html";
        public string node = "//tr";
        public string nodeNombre = "//tr/td[@class='text mp']";
        public int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void cargarItems()
        {
            var articulos = new List<articulo>();

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(enlace);

            var nodes = doc.DocumentNode.SelectNodes(node);
            
            foreach (var node in nodes)
            {
                i++;

                try
                {
                    var articulo = new articulo
                    {
                        posicion = i.ToString(),
                        titulo = node.SelectSingleNode(nodeNombre).InnerText
                    };

                    articulos.Add(articulo);
                }
                catch
                {

                }

                if (i >= 50)
                {
                    break;
                }
            }
            

            foreach (var articulo in articulos)
            {
                gvAmzList.Rows.Add(articulo.posicion, articulo.titulo);
            }
        }

        class articulo
        {
            public string posicion { get; set; }
            public string titulo { get; set; }
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            cargarItems();
        }
    }
}
