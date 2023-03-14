using System;
using System.Collections.Generic;
using System.Linq;

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
        return Math.Round(total / compteur, 2);
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

        return Math.Round(total / compteur, 2);
    }

}
