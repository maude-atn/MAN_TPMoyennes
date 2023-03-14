using System;
using System.Collections.Generic;
using System.Linq;

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
        return Math.Round(total / eleves.Count, 2);
    }
    public double MoyenneGeneraleClasse()
    {
        double total = 0;
        for (int i = 1; i < matieres.Count; i++)
        {
            total = MoyenneMatiereClasse(i);
        }
        return Math.Round(total / matieres.Count, 2);
    }
}
