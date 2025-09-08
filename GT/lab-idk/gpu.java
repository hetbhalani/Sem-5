public class gpu {
    public static void main(String[] args) {
        int[][] cost = {
            {3, 5},
            {2, 5},
            {4, 3}
        };

        int n = cost.length;
        int m = cost[0].length; 
        int size = Math.max(n, m);
        int[][] paddedCost = new int[size][size];
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (i < n && j < m) paddedCost[i][j] = cost[i][j];
                else paddedCost[i][j] = 1000000;
            }
        }

        int[] result = hungarianAlgorithm(paddedCost, size);

        int totalCost = 0;
        System.out.println("Task assignments:");
        for (int i = 0; i < n; i++) {
            int assignedVM = result[i];
            if (assignedVM < m) {
                System.out.println("Task " + i + " -> VM " + assignedVM + " (Cost: " + cost[i][assignedVM] + ")");
                totalCost += cost[i][assignedVM];
            } else {
                System.out.println("Task " + i + " -> Not assigned");
            }
        }
        System.out.println("Total minimum cost: " + totalCost);
    }

    public static int[] hungarianAlgorithm(int[][] cost, int n) {
        int[] u = new int[n+1];
        int[] v = new int[n+1];
        int[] p = new int[n+1];
        int[] way = new int[n+1];
        for (int i = 1; i <= n; ++i) {
            p[0] = i;
            int j0 = 0;
            int[] minv = new int[n+1];
            boolean[] used = new boolean[n+1];
            for (int j = 0; j <= n; ++j) {
                minv[j] = Integer.MAX_VALUE;
                used[j] = false;
            }
            do {
                used[j0] = true;
                int i0 = p[j0], delta = Integer.MAX_VALUE, j1 = 0;
                for (int j = 1; j <= n; ++j) {
                    if (!used[j]) {
                        int cur = cost[i0-1][j-1] - u[i0] - v[j];
                        if (cur < minv[j]) {
                            minv[j] = cur;
                            way[j] = j0;
                        }
                        if (minv[j] < delta) {
                            delta = minv[j];
                            j1 = j;
                        }
                    }
                }
                for (int j = 0; j <= n; ++j) {
                    if (used[j]) {
                        u[p[j]] += delta;
                        v[j] -= delta;
                    } else {
                        minv[j] -= delta;
                    }
                }
                j0 = j1;
            } while (p[j0] != 0);
            do {
                int j1 = way[j0];
                p[j0] = p[j1];
                j0 = j1;
            } while (j0 != 0);
        }
        int[] ans = new int[n];
        for (int j = 1; j <= n; ++j) {
            if (p[j] != 0 && p[j] - 1 < n) {
                ans[p[j]-1] = j-1;
            }
        }
        return ans;
    }
}
