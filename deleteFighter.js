import { db } from "./firebaseSetup.js";
import { doc, deleteDoc } from "firebase/firestore";

const deleteFighter = async (fighterId) => {
  try {
    await deleteDoc(doc(db, "Fighters", fighterId));
    console.log(`Fighter with ID ${fighterId} has been deleted.`);
  } catch (e) {
    console.error("Error deleting fighter: ", e);
  }
};

deleteFighter("Xje1QsiOC10MESKWJNji");