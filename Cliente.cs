public class Cliente{
public string Dni{get;private set;}
public string Apellido{get;private set;}

public string Nombre {get; private set;}
public DateTime FechaInscripcion{get; private set;}
public int TipoEntrada{get;private set;}
public double TotalAbonado{get;private set;}

public Cliente(string dni, string ape, string nom, int tipoE, double totalA){
    Dni = dni;
    Apellido = ape;
    Nombre = nom;
    TipoEntrada = tipoE;
    TotalAbonado = totalA;
    FechaInscripcion = DateTime.Now;
}

public bool CambiarEntrada(int tipoE, double precioE){
    bool seCambio = true;
    if(precioE > TotalAbonado){
        seCambio = true;
        TipoEntrada = tipoE;
        TotalAbonado = precioE;
    }else{
        seCambio = false;
    }
    return seCambio;
}
}




