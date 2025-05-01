import { db } from "./firebaseSetup.js";
import { collection, getDocs, doc, getDoc } from "firebase/firestore";

const getFighterName = async (fighterId) => {
  if (!fighterId) return "Unknown Fighter";
  
  try {
    const fighterDoc = await getDoc(doc(db, "Fighters", fighterId));
    return fighterDoc.exists() ? fighterDoc.data().name : "Unknown Fighter";
  } catch (e) {
    console.error("Error fetching fighter name: ", e);
    return "Unknown Fighter";
  }
};

const getFightRecords = async () => {
  try {
    const querySnapshot = await getDocs(collection(db, "FightRecords"));

    for (const fightDoc of querySnapshot.docs) {
      const fightData = fightDoc.data();
      const winnerName = await getFighterName(fightData.fighterId);
      const loserName = await getFighterName(fightData.opponentId);

      console.log(
        `${winnerName} defeated ${loserName} at ${fightData.eventName} on ${fightData.date}`
      );
    }
  } catch (e) {
    console.error("Error fetching fight records: ", e);
  }
};

getFightRecords();
