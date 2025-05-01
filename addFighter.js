import { db } from "./firebaseSetup.js";
import { collection, addDoc } from "firebase/firestore";

const addFighter = async () => {
  try {
    const docRef = await addDoc(collection(db, "Fighters"), {
      name: "Daniel Cormier",
      weightClass: "Light Heavyweight",
      nationality: "USA",
      wins: 22,
      losses: 3,
      draws: 0,
      fighterImage: "https://images.tapology.com/letterbox_images/769/default/Daniel-Cormier-11.jpg?1606364446"
    });
    console.log("Fighter added with ID: ", docRef.id);
  } catch (e) {
    console.error("Error adding fighter: ", e);
  }
};

addFighter();
