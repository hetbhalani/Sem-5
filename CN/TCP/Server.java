package CN.TCP;
import java.net.*;
import java.io.*;

public class Server {
    public Socket s = null;
    public ServerSocket ss = null; 
    public DataInputStream in = null;
    
    public Server(int port){
        try{
            ss = new ServerSocket(port);
            System.out.println("server started");

            System.out.println("Connecting to client");
            s = ss.accept();
            System.out.println("connected");

            in = new DataInputStream(new BufferedInputStream(s.getInputStream()));
            String m = "";

            while(!m.equals("Over")){
                try{
                    m = in.readUTF();
                    System.out.println(m);
                }
                catch(IOException io){
                    System.out.println(io);
                }
            }
            System.out.println("Closing connection");

            s.close();
            in.close();
        }
        catch(Exception e){
            System.out.println(e);
        }
    }
    public static void main(String[] args) {
        Server s = new Server(3690);
    }
}
