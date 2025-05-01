import { initializeApp } from "firebase/app";
import { getFirestore } from "firebase/firestore";

const firebaseConfig = {
  apiKey: "AIzaSyDrMnjOmEWUkFQNZHu0CEXKWX-4Y0vA9KE",
  authDomain: "ead2-ca2-df0c6.firebaseapp.com",
  projectId: "ead2-ca2-df0c6",
  storageBucket: "ead2-ca2-df0c6.firebasestorage.app",
  messagingSenderId: "230845814218",
  appId: "1:230845814218:web:fd9bb43f6310601dfaeb33",
  measurementId: "G-8002XMZT7H"
};


const app = initializeApp(firebaseConfig);
const db = getFirestore(app);

export { db };
