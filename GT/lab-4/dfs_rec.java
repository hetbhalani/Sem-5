import java.util.ArrayList;
import java.util.Scanner;
import java.util.Stack;

public class dfs_rec {
    static ArrayList<Integer> ans = new ArrayList<>();

    public static void startRec(){
        int V = 5;
        ArrayList<ArrayList<Integer>> adj = new ArrayList<>(V);
        
        for(int i = 0; i<V; i++){
            ArrayList<Integer> temp = new ArrayList<>();
            Scanner sc = new Scanner(System.in);
            int noinp = sc.nextInt();
            
            while(noinp != 0){
                int inp = sc.nextInt();
                temp.add(inp);
                noinp--;
            }
            adj.add(temp);
       }

       System.out.println();

       for (ArrayList<Integer> innerList : adj) {
            for (Integer num : innerList) {
                System.out.print(num + " ");
            }
            System.out.println(); 
        }

        Stack<Integer> st = new Stack<>();
        boolean visited[] = new boolean[5];
        int visNum = 0;

        dfsRec(adj,st,visited,ans,visNum);
    }

    public static void dfsRec(ArrayList<ArrayList<Integer>> adj, Stack<Integer> st, boolean visited[], ArrayList<Integer> ans, int node){
        st.push(node);
        visited[node] = true;
        int temp = st.pop();
        ans.add(temp);

        for(int i : adj.get(temp)){
            if(!visited[i]){
               dfsRec(adj,st,visited,ans,i);
            }
        }
        
    } 
    public static void main(String[] args) {
        startRec();
        for(int i : ans){
            System.out.println(i);
        }
    }
}
