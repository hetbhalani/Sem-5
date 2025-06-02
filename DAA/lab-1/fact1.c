#include<stdio.h>

void main(){
    int ans = 1;
    printf("enter a number: ");
    int n;
    scanf("%d",&n);
    for(int i = 1; i<=n; i++){
        ans*=i;
    }
    printf("%d",ans);

}