import { db } from "./firebaseSetup.js";
import { collection, getDocs } from "firebase/firestore";

const getFighters = async () => {
  const fightersCol = collection(db, "Fighters");
  const fighterSnapshot = await getDocs(fightersCol);
  const fighterList = fighterSnapshot.docs.map(doc => ({ id: doc.id, ...doc.data() }));
  console.log(fighterList);
};

getFighters();