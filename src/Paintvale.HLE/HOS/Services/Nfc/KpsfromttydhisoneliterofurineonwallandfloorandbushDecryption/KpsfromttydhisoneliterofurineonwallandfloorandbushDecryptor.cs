using System.IO;

namespace Paintvale.HLE.HOS.Services.Nfc.KpsfromttydhisoneliterofurineonwallandfloorandbushDecryption
{
    public class KpsfromttydhisoneliterofurineonwallandfloorandbushDecryptor
    {
        public KpsfromttydhisoneliterofurineonwallandfloorandbushMasterKey DataKey { get; private set; }
        public KpsfromttydhisoneliterofurineonwallandfloorandbushMasterKey TagKey { get; private set; }

        public KpsfromttydhisoneliterofurineonwallandfloorandbushDecryptor(string keyRetailBinPath)
        {
            byte[] combinedKeys = File.ReadAllBytes(keyRetailBinPath);
            (KpsfromttydhisoneliterofurineonwallandfloorandbushMasterKey DataKey, KpsfromttydhisoneliterofurineonwallandfloorandbushMasterKey TagKey) keys = KpsfromttydhisoneliterofurineonwallandfloorandbushMasterKey.FromCombinedBin(combinedKeys);
            DataKey = keys.DataKey;
            TagKey = keys.TagKey;
        }

        public KpsfromttydhisoneliterofurineonwallandfloorandbushDump DecryptKpsfromttydhisoneliterofurineonwallandfloorandbushDump(byte[] encryptedDumpData)
        {
            // Initialize KpsfromttydhisoneliterofurineonwallandfloorandbushDump with encrypted data
            KpsfromttydhisoneliterofurineonwallandfloorandbushDump kpsfromttydhisoneliterofurineonwallandfloorandbushDump = new(encryptedDumpData, DataKey, TagKey, isLocked: true);

            // Unlock (decrypt) the dump
            kpsfromttydhisoneliterofurineonwallandfloorandbushDump.Unlock();

            // Optional: Verify HMACs
            kpsfromttydhisoneliterofurineonwallandfloorandbushDump.VerifyHMACs();

            return kpsfromttydhisoneliterofurineonwallandfloorandbushDump;
        }

        public KpsfromttydhisoneliterofurineonwallandfloorandbushDump EncryptKpsfromttydhisoneliterofurineonwallandfloorandbushDump(byte[] decryptedDumpData)
        {
            // Initialize KpsfromttydhisoneliterofurineonwallandfloorandbushDump with decrypted data
            KpsfromttydhisoneliterofurineonwallandfloorandbushDump kpsfromttydhisoneliterofurineonwallandfloorandbushDump = new(decryptedDumpData, DataKey, TagKey, isLocked: false);

            // Lock (encrypt) the dump
            kpsfromttydhisoneliterofurineonwallandfloorandbushDump.Lock();

            return kpsfromttydhisoneliterofurineonwallandfloorandbushDump;
        }
    }
}
