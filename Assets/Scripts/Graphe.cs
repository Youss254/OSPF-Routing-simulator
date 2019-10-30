using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphe : MonoBehaviour {

    public Text costText;
    int c = cableCreation.couples.Count + 1;

    public void PathResult (int o,int t) {

        double[,] adjacence = new double [c,c];
		  for (int i=0 ;i<c ; i++) 
           for (int j=0;j<c;j++){
               adjacence[i,j]=double.PositiveInfinity;
           }

           foreach(List<GameObject> l in cableCreation.couples){
           
               adjacence[ int.Parse(l[0].name.Substring(1,1)) ,   int.Parse(l[1].name.Substring(1,1))] = Mathf.Pow(10,2) / (int.Parse(l[2].name));
               adjacence[ int.Parse(l[1].name.Substring(1,1)) , int.Parse(l[0].name.Substring(1,1))] = Mathf.Pow(10, 2) /(int.Parse(l[2].name));
           }

    

           GetPath(adjacence,o,t);
	}
	
    void GetPath(double[,] ad , int origin , int dest){
        costText = GameObject.Find("Cost").GetComponent<Text>();

        List<int> L =new List<int>();
        double[] d =new double[c];
         for(int h=0; h<c;h++){
             d[h]=double.PositiveInfinity;
         }
         int[] pred =new int[100];

        d[origin]=0;
        L.Add(origin);
        for (int k=0 ; k<c ;k++){
            if (k!=origin){
                d[k]= ad[origin,k];
                pred[k]=origin;
            }
        }
        while (L.Count<c){
            double min = double.PositiveInfinity;
            int y =0;
            for (int k=0; k<c; k++){
                if(!L.Contains(k)){
                    if(d[k]<min){
                        min=d[k];
                        y=k;
                    }
                }

            }
            if (y==0){
                break;
            }
            L.Add(y);
             for (int k=0; k<c; k++){
                if(!L.Contains(k)){
                    if(d[k]>(d[y]+ad[y,k]) ){
                        d[k]=d[y]+ad[y,k];
                        pred[k]=y;
                    }
                }
            }
        } 

        List<int> ch= new List<int>();
        int f = dest;
        while (f!=origin){
            //ch+=" ,"+f.ToString();
            ch.Add(f);
            f=pred[f];
        }
        //ch += " ,"+ origin.ToString();
        ch.Add(origin);
        ch.Reverse();
       
        if (d[dest]== double.PositiveInfinity){

        Debug.Log("Pas de chemin");
        costText.text = "No route founded !";
        }
        else{
            foreach(int st in ch){
                Debug.Log(st);
            }
            Debug.Log("distance is "+ d[dest]);
            costText.text = "Cost is " + d[dest];
        }
        for(int p=0;p<ch.Count-1;p++)
        {
          for(int cp=0; cp<cableCreation.couples.Count;cp++)
            {
                if((int.Parse(cableCreation.couples[cp][0].name.Substring(1,1))==ch[p] && int.Parse(cableCreation.couples[cp][1].name.Substring(1, 1)) == ch[p+1])|| (int.Parse(cableCreation.couples[cp][1].name.Substring(1, 1)) == ch[p] && int.Parse(cableCreation.couples[cp][0].name.Substring(1, 1)) == ch[p + 1]))
                {
                    ColorateLine(cableCreation.couples[cp][2].GetComponent<LineRenderer>());
                }
            }
        }
        
    }
    void ColorateLine(LineRenderer l)
    {
        l.material = new Material(Shader.Find("Sprites/Default"));
        l.SetColors(Color.green, Color.green);
    }




}


