class adjacency{
    public static void main(String[] args) {
        int [][] a = {
            {0,1},{1,2},{2,0},{3,0},{0,2}
        };

        for(int i = 0; i<4; i++){
            System.out.print(i+" -> ");
            for(int j = 0; j<a.length; j++){
                if(a[j][0] == i){
                    System.out.print(a[j][1]+" ");
                }
            }
            System.out.println();
        }
    }
}