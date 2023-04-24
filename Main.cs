using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

int elecc = 0;
string dni = " ", ape = " ", nom = "";
int tipoEntra = 0, cantEntradas1 = 0, cantEntradas2 = 0, cantEntradas3 = 0, cantEntradas4 = 0, totalAbona = 0, id = 0;

Dictionary<int, Cliente > dicCliente = new Dictionary<int, Cliente>();

while(elecc != 5){
    menu();
    elecc = int.Parse(Console.ReadLine());
    if(elecc == 1){
        dni = ingresarString("Ingrese su dni");
        ape = ingresarString("Ingrese su apelldio");
        nom = ingresarString("Ingresar su nombre");
        Console.Clear();
        menuEntrada();
        tipoEntra = ingresarInt("Ingrese su tipo de entrada");
        totalAbona = ingresarInt("Ingresa cuanto pago");
        CompraDeEntrada(tipoEntra,totalAbona,ref cantEntradas1,ref cantEntradas2,ref cantEntradas3, ref cantEntradas4);
        Cliente c = new Cliente (dni,ape,nom,tipoEntra,totalAbona);
        dicCliente.Add(id = Tiquetera.DevolverUltimo(),c);
    }
    else if(elecc == 2){
        int totaldia1 = cantEntradas1*15000, totaldia2 = cantEntradas2*30000, totaldia3 = cantEntradas3*10000, total = totaldia1+totaldia2+totaldia3+cantEntradas4*40000;
        Console.WriteLine("La cantidad de clientes inscriptos es " + dicCliente.Count);
        Console.WriteLine("Porcentaje de ventas de cada tipo de entrada respecto al total"+Environment.NewLine+"Se vendio "+cantEntradas1*100/dicCliente.Count+"% del tipo 1"+Environment.NewLine+"Se vendio "+cantEntradas2*100/dicCliente.Count+"% del tipo 2"+Environment.NewLine+"Se vendio "+cantEntradas3*100/dicCliente.Count+"% del tipo 3"+Environment.NewLine+"Se vendio "+cantEntradas4*100/dicCliente.Count+"% del tipo 4");
        Console.WriteLine("El dia 1 se recaudo un total de "+totaldia1+"$"+Environment.NewLine+"El dia 2 se recaudo un total de "+totaldia2+"$"+Environment.NewLine+"El dia 3 se recaudo un total de "+totaldia3+"$");
        Console.WriteLine("El total recaudado fue de "+total+"$");
    }
    else if(elecc == 3){
       int buscID = ingresarInt("Ingrese el id del cliente que quiere buscar");
       Console.WriteLine("Su dni es: "+dicCliente[buscID].Dni+Environment.NewLine+"Su Apellido es: "+dicCliente[buscID].Apellido+Environment.NewLine+"Su nombre es: "+ dicCliente[buscID].Nombre+Environment.NewLine+"Compro la entrada tipo "+dicCliente[buscID].FechaInscripcion+Environment.NewLine+"Su tipo de entrada es: "+dicCliente[buscID].TipoEntrada+Environment.NewLine+"Abono un total de: "+dicCliente[buscID].TotalAbonado+"$"); 
    }
    else if(elecc == 4){
        int buscID = ingresarInt("Ingrese el id del cliente que va a cambiar su entrada");
        int cambEntrada = ingresarInt("Ingrese a cual entrada va a cambiar escribiendo 1,2,3 o 4 para el Full pass");
        double precioEntrada = 0;
        if(cambEntrada == 1){
            precioEntrada = 15000;
        }else if(cambEntrada == 2){
            precioEntrada = 30000;
        }else if(cambEntrada == 3){
            precioEntrada = 10000;
        }else{
            precioEntrada = 40000;
        }
        bool cambiar = dicCliente[buscID].CambiarEntrada(cambEntrada, precioEntrada);
        if(cambiar == true){
            Console.WriteLine("Se cambio su entrada exitosamente");
        }else{
            Console.WriteLine("No se puede cambiar la entrada porque la opcion elegida tiene un precio menor a la actual");
        }
    }
        
    
}
static int ingresarInt(string msj){
    Console.WriteLine(msj);
    int x = int.Parse(Console.ReadLine());
    return x;
}
static string ingresarString(string msj){
    Console.WriteLine(msj);
    string x = Console.ReadLine();
    return x;
}

static void menu(){
    Console.WriteLine("1-Nueva Inscripción"+Environment.NewLine+"2-Obtener Estadísticas del Evento"+Environment.NewLine+"3-Buscar Cliente"+Environment.NewLine+"4-Cambiar entrada de un Cliente"+Environment.NewLine+ "5-Salir");
}

static void menuEntrada(){
    Console.WriteLine("1-Día 1 , valor a abonar $15000"+" 2-Día 2, valor a abonar $30000"+" 3-Día 3, valor a abonar $10000"+" 4-Full Pass, valor a abonar $40000");
}

static void CompraDeEntrada(int tipoE,int pagaUsuario,ref int cantEntradas1,ref int cantEntradas2,ref int cantEntradas3, ref int cantEntradas4){
    int valorE = 0;
    if(tipoE == 1){
        valorE = 15000;
        cantEntradas1++;
    }else if(tipoE == 2){
        valorE = 30000;
        cantEntradas2++;
    }else if(tipoE == 3){
        valorE = 10000;
        cantEntradas3++;
    }else if(tipoE == 4){
        valorE = 40000;
        cantEntradas4++;
    }
    if(pagaUsuario>valorE){
        pagaUsuario -= valorE;
        Console.Write("El vuelto es de; "+pagaUsuario);
    }else{
        while(pagaUsuario<valorE){
            Console.WriteLine("El tipo de entrada que selecciono no lo puede pagar");
            menuEntrada();
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Vuelva a pagar");
            pagaUsuario = int.Parse(Console.ReadLine());
        }
        
    }
    Thread.Sleep(2000);
    Console.Clear();
}