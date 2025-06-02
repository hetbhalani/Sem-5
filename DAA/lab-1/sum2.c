#include<stdio.h>

int sum(int a){
    if(a == 1){
        return 1;
    }

    return a + sum(a-1);
}

void main(){
    int n = 10;
    int ans = sum(n);
    printf("%d", ans);
}