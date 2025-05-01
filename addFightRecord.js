import { db } from "./firebaseSetup.js";
import { collection, addDoc } from "firebase/firestore";

const addFightRecord = async (fighterId, opponentId) => {
  try {
    const docRef = await addDoc(collection(db, "FightRecords"), {
      fighterId: fighterId,
      opponentId: opponentId,
      eventName: "UFC 214",
      result: "Win",
      date: "2017-07-29"
    });
    console.log("Fight record added with ID: ", docRef.id);
  } catch (e) {
    console.error("Error adding fight record: ", e);
  }
};

addFightRecord("hKpphAsMZpmCguN1DHJw", "RbbkP2c7mQUR625oqCrN");