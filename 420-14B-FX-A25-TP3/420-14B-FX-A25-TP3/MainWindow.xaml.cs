using _420_14B_FX_A25_TP3.classes;
using _420_14B_FX_A25_TP3.enums;
using System.Collections.Generic;
using System.Windows;

namespace _420_14B_FX_A25_TP3
{
    public partial class MainWindow : Window
    {
        private BilleterieDAL dal;
        private Facture factureCourante;
        private List<Evenement> evenements;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                dal = new BilleterieDAL();
                factureCourante = new Facture();
                evenements = dal.ObtenirListeEvenements();
            }
            catch
            {
                MessageBox.Show("Erreur lors de l'initialisation.");
            }
        }

        private void btnAjouterEvenement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FormEvenement frm = new FormEvenement((EtatFormulaire)0);

                if (frm.ShowDialog() == true)
                {
                    dal.AjouterEvenement(frm.Evenement);
                    evenements = dal.ObtenirListeEvenements();
                }
            }
            catch
            {
                MessageBox.Show("Erreur lors de l'ajout.");
            }
        }

        private void btnModifierEvenement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (evenements.Count == 0)
                    return;

                FormEvenement frm = new FormEvenement((EtatFormulaire)0, evenements[0]);

                if (frm.ShowDialog() == true)
                {
                    dal.ModifierEvenement(frm.Evenement);
                }
            }
            catch
            {
                MessageBox.Show("Erreur lors de la modification.");
            }
        }

        private void btnSupprimerEvenement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (evenements.Count == 0)
                    return;

                dal.SupprimerEvenement(evenements[0]);
            }
            catch
            {
                MessageBox.Show("Erreur lors de la suppression.");
            }
        }

        private void BtnSupprimerEvenement_Click(object sender, RoutedEventArgs e)
        {
            btnSupprimerEvenement_Click(sender, e);
        }

        private void btnRechercheEvenement_Click(object sender, RoutedEventArgs e)
        {
            // Non requis
        }

        private void btnNouvelleFacture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                factureCourante = new Facture();
            }
            catch
            {
                MessageBox.Show("Erreur lors de la création de la facture.");
            }
        }

        private void btnPayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dal.AjouterFacture(factureCourante);
                factureCourante = new Facture();
            }
            catch
            {
                MessageBox.Show("Erreur lors du paiement.");
            }
        }

        private void btnRechercheFacture_Click(object sender, RoutedEventArgs e)
        {
            // Non requis
        }
    }
}
