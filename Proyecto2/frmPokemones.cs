using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using Proyecto2;

namespace winform_app
{
    public partial class frmPokemones : Form
    {
        private List<Pokemon> listaPokemon; //esta guardando la lista de Pokemones.
        public frmPokemones()
        {
            InitializeComponent();
        }

        private void frmPokemones_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();
            dgvPokemones.DataSource = listaPokemon; // data source : recibe un origen de datos y los modela en la tabla. negocio listar : recibe una lista de datos.
            dgvPokemones.Columns["UrlImagen"].Visible = false ; // oculto columna de url imagen porque no la quiero ver.
            cargarImagen(listaPokemon[0].UrlImagen);

        }

        private void dgvPokemones_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem; //de la grilla de la fila actual el objeto enlazado transformado en pokemon lo guardo en el "Pokemon seleccionado".
            cargarImagen(seleccionado.UrlImagen);
        }

        private void cargarImagen(string Imagen)
        {
            try
            {
                pbxPokemon.Load(Imagen); // si falla cargar imagen porque no tiene muestra la foto de que no contiene imagen (abajo).
            }

            catch (Exception ex)
            {
                pbxPokemon.Load("https://images.wondershare.com/repairit/aticle/2021/07/resolve-images-not-showing-problem-1.jpg");
            }
        }


        private void btnAgregar_Click_1(object sender, EventArgs e) //me lleva a la otra ventana.
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog(); // no permita salir de la app, ir a otra ventana hasta q no termine de trabajar una.

        }
    }   

}

