using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.MoyenneMatiereEleve(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.MoyenneGeneraleEleve() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.NomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.MoyenneMatiereClasse(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.NomClasse + ", Moyenne Generale : " + sixiemeA.MoyenneGeneraleClasse() + "\n");
            Console.Read();
        }
    }
}
// Classes fournies par HNI Institut
class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }
    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}


class Classe
{   
    public string NomClasse { get; private set; }
    public List<Eleve> eleves = new List<Eleve>();
    public List<string> matieres = new List<string>();
    public double moyenne;
    public Classe(string nC)
    {
        NomClasse = nC;
    }

    public void ajouterEleve(string p, string n)
    {
        eleves.Add(new Eleve(p, n));
    }
    public void ajouterMatiere(string matiere)
    {
        matieres.Add(matiere);
    }
    public double MoyenneMatiereClasse(int m)
    {
        double total = 0;
        foreach (Eleve e in eleves)
        {
            total = total + e.MoyenneMatiereEleve(m);
        }
        return total / eleves.Count;
    }
    public double MoyenneGeneraleClasse()
    {
        double total = 0;
        for (int i = 1; i < matieres.Count; i++)
        {
            total = MoyenneMatiereClasse(i);
        }
        return total / matieres.Count;
    }
}

class Eleve
{
    public string prenom { get; private set; }
    public string nom { get; private set; }
    
    public List<Note> note = new List<Note>();
    public Eleve(string p, string n)
    {
        prenom = p;
        nom = n;
    }

    public void ajouterNote(Note n)
    {
        note.Add(n);
    }
    public double MoyenneMatiereEleve(int m)
    {
        double total = 0;
        int compteur = 0;
        foreach (Note n in note)
        {
            if (n.matiere == m)
            {
                total = total + n.note;
                compteur++;
            }
        }
        return total / compteur;
    }
    public double MoyenneGeneraleEleve()
    {
        double total = 0;
        int compteur = 0;
        for (int i = 1; i < note[note.Count - 1].matiere; i++)
        {
            total = total + MoyenneMatiereEleve(i);
            compteur++;
        }

        return total / compteur;
    }

}
