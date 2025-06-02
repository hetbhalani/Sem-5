#include<stdio.h>

void main(){
    int a = 2;
    int b = 3;
    int ans = 1;

    for(int i = 0; i<b; i++){
        ans*= a;    
    }
    printf("%d", ans);
}
