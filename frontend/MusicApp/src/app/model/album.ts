export interface Album {
  id?:string;
  titulo?:string;
  musica?: musica[]
}

export interface musica {
  id:string;
  titulo?:string;
  duracao?:string;
}
