package CN.TCP;
import java.io.*;
import java.net.*;

public class Client {
    public Socket s = null;
    public DataInputStream in = null;
    public DataOutputStream out = null;

    public Client(String address,int port){
         try {
            s = new Socket(address, port);
            System.out.println("Connected");
            in = new DataInputStream(System.in);

            out = new DataOutputStream(s.getOutputStream());
        }
        catch(Exception e){
            System.out.println(e);
        }

        String m = "";
    
        while(!m.equals("Over")){
            try {
                m = in.readLine();
                out.writeUTF(m);
            }
            catch(Exception e){
                System.out.println(e);
            }
        }

        try {
            in.close();
            out.close();
            s.close();
        }
        catch (IOException i) {
            System.out.println(i);
        }
    }
    public static void main(String[] args) {
        Client c = new Client("127.0.0.1", 3690);
    }
}
