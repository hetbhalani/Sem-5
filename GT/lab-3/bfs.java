import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

class bfs{
    public static void main(String[] args) {
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

        Queue<Integer> q = new LinkedList<>();
        ArrayList<Integer> ans = new ArrayList<>();
        boolean [] isVisited  = new boolean[V];

        isVisited[0] = true;
        q.add(0);

        while(!q.isEmpty()){
            int node = q.poll();
            ans.add(node);

            for(int a : adj.get(node)){
                if(!isVisited[a]){
                    q.add(a);
                    isVisited[a] = true;
                }
            }
        }
        for(int elm : ans){
            System.out.println(elm);
        }
    }
}