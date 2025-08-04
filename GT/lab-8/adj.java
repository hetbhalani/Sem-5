import java.util.Scanner;

class adj{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        System.out.println("Enter number of vertices: ");
        int v = sc.nextInt();

        System.out.println("Enter number of Edges: ");
        int e = sc.nextInt();

        int edges[][] = new int[e][2];

        for(int i = 0; i<e; i++){
            for(int j = 0;j<2;j++){
                edges[i][j] = sc.nextInt();
            }
        }

        int adj[][] = new int[v][v];


        // for(int i = 0; i<e; i++){
        //     for(int j = 0;j<2;j++){
        //         System.out.println(edges[i][j]);
        //     }
        //     System.out.println();
        // }

        for(int i = 0; i<v; i++){
            for(int j = 0;j<v;j++){
                adj[i][j] = 0;
            }
        }

        for(int i = 0; i<e; i++){
            adj[edges[i][0]][edges[i][1]] = 1;
            adj[edges[i][1]][edges[i][0]] = 1;
        }

        System.out.println("ADJ matrix");
         for(int i = 0; i<v; i++){
            for(int j = 0;j<v;j++){
                System.out.print(adj[i][j] + " ");
            }
            System.out.println();
        }

        //degree

        int deg[][] = new int[v][v];

        for(int i = 0; i<v; i++){
            for(int j = 0;j<v;j++){
                deg[i][j] = 0;
            }
        }

        for(int i = 0; i<v; i++){
            int sum = 0;
            for(int j = 0;j<v; j++){
                 sum += adj[i][j];
            }
            deg[i][i] = sum;
        }

        System.out.println("DEG matrix");
         for(int i = 0; i<v; i++){
            for(int j = 0;j<v;j++){
                System.out.print(deg[i][j] + " ");
            }
            System.out.println();
        }
    }
}