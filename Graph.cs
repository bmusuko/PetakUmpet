using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Linq;
using System.IO;

namespace Graph{
	
	class graph{
		private int simpul;
		private List<Int32>[] sisi;
		private Int32[] j1;
		private Stack<Int32> jalur;

		public graph(int v){
			simpul = v;
			sisi = new List<Int32>[v+1];
			for(int i=0;i<=v;i++){
				sisi[i] = new List<Int32>();
			}
		}
		
		public void addEdge(int v,int s){
			sisi[v].Add(s);
			sisi[s].Add(v);
		}

		public void kasus0(int x,int y){
			DFS(y,1);
			if(j1.Contains(x)){
				Console.WriteLine("YA");
			} else{
				Console.WriteLine("TIDAK");
			}
		}

		public void kasus1(int x,int y){
			DFS(y,1);
			int[] jalur1 = new Int32[j1.Length];
			Array.Copy(j1,0,jalur1,0,j1.Length);
			DFS(y,x);
			bool cek = true;
			int n = jalur1.Length;
			int m = j1.Length;
			int j,i =0;			
			while(i<n-1 && cek){ // tidak mengecek start state
				j= 0;
				while(j<m-1 && cek){ // tidak mengecek start state
					if(j1[j] == jalur1[i]){
						cek = false;
					} else{
						j++;
					}
				}
				i++;
			}
			
			if(cek){
				Console.WriteLine("YA");
			} else{
				Console.WriteLine("TIDAK");
			}
		}
		public void DFS(int s,int d){
			bool[] visited = new bool[simpul+1];
			jalur = new Stack<Int32>();
			visited[s] = true;
			jalur.Push(s);
			if(s!=d){
				foreach(int i in sisi[s]) { 
        			DFSR(i,d,visited);
        			//Console.WriteLine(s);
        		}    		 
			} else{
				j1 = new int[jalur.Count];
				jalur.CopyTo(j1,0);
			}

		}

		public void DFSR(int s,int d,bool[] visited){
			jalur.Push(s);
        	//Console.WriteLine(s);			
			visited[s] = true;
			if(s != d){
				foreach(int i in sisi[s]){
        			if(!visited[i]){
        				DFSR(i,d,visited);  					
        			}
				}
			} else{
				j1 = new int[jalur.Count];
				jalur.CopyTo(j1,0);
			}
			visited[s] = false;
			jalur.Pop();
		}

	}
	class Test{
		public static void Main(String[] args){
			using(TextReader reader = new StreamReader("tc.txt")){
				int v = Convert.ToInt32(reader.ReadLine());
				int x,y,k;
				string[] tokens;
				graph g = new graph(v);
				for(int i =1;i<v;i++){
					tokens = reader.ReadLine().Split();
					x = int.Parse(tokens[0]);
					y = int.Parse(tokens[1]);
					g.addEdge(x,y);
				}
				int q = Convert.ToInt32(reader.ReadLine());
				for(int i=0;i<q;i++){	
					tokens = reader.ReadLine().Split();
					k = int.Parse(tokens[0]);
					x = int.Parse(tokens[1]);
					y = int.Parse(tokens[2]);
					if(k==0){
						g.kasus0(x,y);	
					} else if(k==1){
						g.kasus1(x,y);
					}
				}
			}
		}
	}
}