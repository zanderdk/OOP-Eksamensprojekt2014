﻿using System;

namespace OOP_EksamensOpgave2014
{
    class RegistreringnummerException : Exception
    {
        public RegistreringnummerException() {}
        public RegistreringnummerException(string s)
            : base(s) {}
        public RegistreringnummerException(string s, Exception ex)
            : base(s, ex) {}
    }
}
