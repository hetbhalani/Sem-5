#include<stdio.h>

int cnt = 0;

int gano(int a){
    if(a == 0){
        return cnt;
    }
    cnt += 1;

    return gano(a/10);
}

void main(){
    printf("%d", gano(1234567));
}