﻿namespace ProvaPub.Models
{
    public class PropriedadesComunsLista<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
