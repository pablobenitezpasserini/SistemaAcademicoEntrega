﻿namespace SistemaAcademico.AccesoDatos
{
    public interface IAccesoDatos<T>
    {
        List<T> Leer();
        void Guardar(List<T> lista);
    }
}
