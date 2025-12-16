using _420_14B_FX_A25_TP3.classes;
using _420_14B_FX_A25_TP3.enums;
using System;
using System.Windows;

namespace _420_14B_FX_A25_TP3
{
    public partial class FormEvenement : Window
    {
        private EtatFormulaire etat;
        public Evenement Evenement { get; private set; }

        public FormEvenement(EtatFormulaire etatFormulaire, Evenement evenement = null)
        {
            InitializeComponent();

            try
            {
                etat = etatFormulaire;

                if (evenement != null)
                    Evenement = evenement;
            }
            catch
            {
                MessageBox.Show("Erreur lors de l'ouverture du formulaire.");
            }
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Evenement == null)
                {
                    Evenement = new Evenement(
                        "Nouvel événement",
                        (TypeEvenement)0,
                        DateTime.Now,
                        0,
                        1,
                        null
                    );
                }

                DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Erreur lors de l'enregistrement.");
            }
        }

        private void btnParcourir_Click(object sender, RoutedEventArgs e)
        {
            // Non requis par les consignes
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
