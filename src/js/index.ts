//import axios from 'axios';
import Axios,{} from '../../node_modules/axios/index'
interface highscore{
  name:string, score:number
};

//let Buttonhent: HTMLButtonElement = <HTMLButtonElement> document.getElementById("getList");
let hentliste = document.getElementById("list_highscore") as HTMLTextAreaElement;

// Buttonhent.addEventListener("click", MouseEvent => {

    Axios.get('https://highscore20181022124259.azurewebsites.net/api/Highscore')
    .then(function (response) {

      // handle success
      let hs = response.data as highscore[];
      hs.forEach(scores => {
        hentliste.value += "Name" + scores.name + "Score" + scores.score + "\n";
      });
      console.log(response + "HEJ");
    })
    .catch(function (error) {
      // handle error
      console.log(error + "nej");
    });
  // hent.innerHTML = JSON.stringify(response.data)
  //Hent navn
  //hent.innerHTML = JSON.stringify(response.data[1].name)
  //Hent id 0
  //hent.innerHTML = JSON.stringify(response.data[0].id)
  //Hent body virker
  //hent.innerHTML = JSON.stringify(response.data[0].body)
  //Hent alt
  //hent.innerHTML = JSON.stringify(response.data)
    // console.log(response);
  // })
  // .catch(function (error) {
  //   console.log(error);
    // });