using _420_14B_FX_A25_TP3.classes;
using System.Collections.Generic;
using System.Linq;

namespace _420_14B_FX_A25_TP3
{
    public class BilleterieDAL
    {
        private List<Evenement> _evenements = new List<Evenement>();
        private uint _idCourant = 1;

        public List<Evenement> ObtenirListeEvenements()
        {
            try
            {
                return _evenements;
            }
            catch
            {
                return new List<Evenement>();
            }
        }

        public void AjouterEvenement(Evenement e)
        {
            try
            {
                e.Id = _idCourant++;
                _evenements.Add(e);
            }
            catch
            {
            }
        }

        public void ModifierEvenement(Evenement e)
        {
            try
            {
                Evenement existant = _evenements.First(ev => ev.Id == e.Id);

                existant.Nom = e.Nom;
                existant.Type = e.Type;
                existant.DateHeure = e.DateHeure;
                existant.Prix = e.Prix;
                existant.NbPlaces = e.NbPlaces;
                existant.ImagePath = e.ImagePath;
            }
            catch
            {
            }
        }

        public void SupprimerEvenement(Evenement e)
        {
            try
            {
                _evenements.RemoveAll(ev => ev.Id == e.Id);
            }
            catch
            {
            }
        }

        public void AjouterFacture(Facture f)
        {
            try
            {
                // Aucune persistance requise
            }
            catch
            {
            }
        }
    }
}
