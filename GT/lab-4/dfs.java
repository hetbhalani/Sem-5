import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Stack;
import java.util.Scanner;

class dfs{
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

        Stack<Integer> st = new Stack<>();
        boolean visited[] = new boolean[5];
        ArrayList<Integer> ans = new ArrayList<>();

        visited[0] = true;
        st.push(0);

        while(!st.isEmpty()){
            int node = st.peek();
            st.pop();
            ans.add(node);

            for(int i : adj.get(node)){
                if(!visited[i]){
                    visited[i] = true;
                    st.push(i);
                }
            }
        }
        for(int i : ans){
            System.out.println(i);
        }
    }
}