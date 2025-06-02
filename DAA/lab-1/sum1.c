#include<stdio.h>

void main(){
    int n = 10;
    int ans = 0;

    for(int i = 0; i<=n; i++){
        ans += i;    
    }
    printf("%d", ans);
}