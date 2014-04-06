﻿using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til erhverv
    class Erhvervbil : Personbil
    {
        public bool Sikkerhedsbøjle;

        public double Lasteevne;

        public Erhvervbil(Brændstof brændstof, int årgang, int antalSæder, bool trækkrog)
            : base(brændstof, årgang)
        {
            if (trækkrog)
            {
                _trækkrog = true;
            }
            else
            {
                throw new ArgumentException("Personbiler til erhverv skal være udstyret med en trækkrog");
            }
            
        }

        public override Kørekorttype Kørekorttype
        {
            get
            {
                if (Lasteevne > 750)
                {
                    return Kørekorttype.BE;
                }
                return Kørekorttype.B;
            }
        }

        public override int AntalSæder
        {
            get { return _antalSæder; }
            set
            {
                if (value != 2)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _antalSæder = value;
            }
        }

        public override bool Trækkrog
        {
            get { return _trækkrog; }
            set 
            {
                if (value)
                {
                    _trækkrog = true;
                }
                else
                {
                    throw new ArgumentException("Personbiler til erhverv skal være udstyret med en trækkrog");
                }
            }
        }
    }
}
