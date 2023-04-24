public class Tiquetera{

    static int UltimoID = 0;
    public static int DevolverUltimo(){
        UltimoID++; 
        return UltimoID;      
    }
}