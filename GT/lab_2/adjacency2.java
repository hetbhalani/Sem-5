import java.util.ArrayList;
import java.util.HashMap;

public class adjacency2 {
    public static void main(String[] args) {
        HashMap<Integer, ArrayList<Integer>> map = new HashMap<>();

        int [][] edges = {
            {0,1},{1,2},{1,3},{2,0},{3,0},{0,3}
        };

        for(int i = 0; i<edges.length; i++){
            // map.putIfAbsent(edges[i][0], edges[i][1]);
            
            if(map.containsKey(edges[i][0])){
                map.get(edges[i][0]).add(edges[i][1]);
            }
            else{
                map.put(edges[i][0], new ArrayList<>());
                map.get(edges[i][0]).add(edges[i][1]);
            }
        }

        System.err.println(map);
    }
}
