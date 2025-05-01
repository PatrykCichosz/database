import express from "express";
import admin from "firebase-admin";
import cors from "cors";
import dotenv from "dotenv";

dotenv.config();

admin.initializeApp({
  credential: admin.credential.cert(process.env.GOOGLE_APPLICATION_CREDENTIALS)
});

const db = admin.firestore();
const app = express();
app.use(cors());
app.use(express.json());


app.get("/api/fighters", async (req, res) => {
  try {
    const snapshot = await db.collection("Fighters").get();
    const fighters = snapshot.docs.map(doc => ({ id: doc.id, ...doc.data() }));
    res.json(fighters);
  } catch (error) {
    res.status(500).json({ error: "Failed to fetch fighters" });
  }
});

app.get("/api/fightRecords", async (req, res) => {
  try {
    const snapshot = await db.collection("FightRecords").get();
    const fightRecords = snapshot.docs.map(doc => ({ id: doc.id, ...doc.data() }));
    res.json(fightRecords);
  } catch (error) {
    res.status(500).json({ error: "Failed to fetch fight records" });
  }
});

app.get("/api/fighters/:id", async (req, res) => {
  try {
    const docRef = db.collection("Fighters").doc(req.params.id);
    const doc = await docRef.get();

    if (!doc.exists) {
      return res.status(404).json({ error: "Fighter not found" });
    }

    res.json({ id: doc.id, ...doc.data() });
  } catch (error) {
    res.status(500).json({ error: "Failed to fetch fighter" });
  }
});

app.get("/api/fightRecords/:fighterId", async (req, res) => {
  try {
    const snapshot = await db.collection("FightRecords").where("fighterId", "==", req.params.fighterId).get();
    const fightRecords = snapshot.docs.map(doc => ({ id: doc.id, ...doc.data() }));

    res.json(fightRecords);
  } catch (error) {
    res.status(500).json({ error: "Failed to fetch fight records" });
  }
});

const PORT = process.env.PORT || 5000;
app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
