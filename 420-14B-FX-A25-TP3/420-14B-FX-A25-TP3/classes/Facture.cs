using System;
using System.Collections.Generic;

namespace _420_14B_FX_A25_TP3.classes
{
    /// <summary>
    /// Représente une facture contenant les billets achetés pour un ou plusieurs événements.
    /// </summary>
    public class Facture
    {
      

        private uint _id;
        private DateTime? _date;
        private List<Billet> _billets;

        /// <summary>
        /// Identifiant unique de la facture.
        /// </summary>
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Date de création de la facture.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Lancée si la date de création est dans le futur.
        /// </exception>
        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// Liste des billets associés à la facture.
        /// </summary>
        public List<Billet> Billets
        {
            get { return _billets; }
            private set { _billets = value ?? new List<Billet>(); }
        }

        /// <summary>
        /// Montant total avant taxes.
        /// </summary>
        public decimal SousTotal
        {
            get 
            {
                decimal total = 0;
                foreach (Billet b in Billets)
                    total += b.Evenement.Prix * b.Quantite;
                return total;
            }
        }

        /// <summary>
        /// Montant de la TPS calculé sur le sous-total.
        /// </summary>
        public decimal TPS
        {
            get 
            { 
                return SousTotal * 0.05m; 
            }
        }

        /// <summary>
        /// Montant de la TVQ calculé sur le sous-total.
        /// </summary>
        public decimal TVQ
        {
            get 
            { 
                return SousTotal * 0.09975m; 
            }
        }

        /// <summary>
        /// Montant total (taxes incluses).
        /// </summary>
        public decimal Total
        {
            get 
            { 
                return SousTotal + TPS + TVQ; 
            }
        }

        /// <summary>
        /// Initialise une facture vide.
        /// </summary>
        public Facture()
        {
            Date = DateTime.Now;
            Billets = new List<Billet>();
        }

        /// <summary>
        /// Initialise une facture complète avec ses données.
        /// </summary>
        /// <param name="id">Identifiant de la facture.</param>
        /// <param name="date">Date de création de la facture.</param>
        /// <param name="sousTotal">Montant avant taxes.</param>
        /// <param name="tps">Montant de la TPS.</param>
        /// <param name="tvq">Montant de la TVQ.</param>
        /// <param name="total">Montant total avec taxes.</param>
        /// <param name="billets">Liste des billets inclus dans la facture.</param>
        public Facture(uint id, DateTime date, decimal sousTotal, decimal tps, decimal tvq, decimal total, List<Billet> billets)
        {
            Id = id;
            Date = date;
            Billets = billets;
        }

        /// <summary>
        /// Ajoute un billet à la facture.
        /// Si un billet du même événement existe déjà, sa quantité est augmentée.
        /// Sinon, le billet est ajouté à la liste.
        /// </summary>
        /// <param name="billet">Billet à ajouter.</param>
        /// <exception cref="ArgumentNullException">
        /// Lancée si le billet est nul.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Lancée si la quantité maximale pour un événement est atteinte.
        /// </exception>
        public void AjouterBillet(Billet billet)
        {
            if (billet == null)
                throw new ArgumentNullException(nameof(billet));

            foreach (Billet b in Billets)
            {
                if (b == billet)
                {
                    b.Quantite += billet.Quantite;
                    return;
                }
            }

            Billets.Add(billet);
        }

        /// <summary>
        /// Supprime un billet de la facture.
        /// Si plusieurs billets du même événement sont présents, la quantité est diminuée.
        /// Si la quantité tombe à zéro, le billet est retiré de la facture.
        /// </summary>
        /// <param name="billet">Billet à retirer.</param>
        /// <exception cref="ArgumentNullException">
        /// Lancée si le billet est nul.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Lancée si le billet n’existe pas dans la facture.
        /// </exception>
        public void SupprimerBillet(Billet billet)
        {
            if (billet == null)
                throw new ArgumentNullException(nameof(billet));

            for (int i = 0; i < Billets.Count; i++)
            {
                if (Billets[i] == billet)
                {
                    Billets[i].Quantite--;

                    if (Billets[i].Quantite <= 0)
                        Billets.RemoveAt(i);

                    return;
                }
            }

            throw new InvalidOperationException("Le billet n'existe pas dans la facture.");
        }
    }
}
