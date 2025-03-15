using System;
using System.Runtime.InteropServices;

namespace Libgpgme.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class _gpgme_subkey // gpgme_subkey_t
    {
        /* A subkey from a key.  */
        public IntPtr next;

        /* True if subkey is revoked. 1 
              unsigned int revoked : 1;

           True if subkey is expired. 2 
              unsigned int expired : 1;

           True if subkey is disabled. 4 
              unsigned int disabled : 1;

           True if subkey is invalid. 8 
              unsigned int invalid : 1;

           True if subkey can be used for encryption. 16 
              unsigned int can_encrypt : 1;

           True if subkey can be used for signing. 32 
              unsigned int can_sign : 1;

           True if subkey can be used for certification. 64 
              unsigned int can_certify : 1;

           True if subkey is secret. 128 
              unsigned int secret : 1;

           True if subkey can be used for authentication. 256 
              unsigned int can_authenticate : 1;

           True if subkey is qualified for signatures according to German law. 512 
              unsigned int is_qualified : 1;

           True if the secret key is stored on a smart card. 1024
              unsigned int is_cardkey : 1;

           True if the key is compliant to the de-vs mode. 2048
              unsigned int is_de_vs : 1;

           True if the key can be used for restricted encryption (ADSK). 4096
              unsigned int can_renc : 1;

           True if the key can be used for timestamping. 8192
              unsigned int can_timestamp : 1;

           True if the private key is possessed by more than one person. 16384
              unsigned int is_group_owned : 1;

           The compliance mode (is_de_vs) has not yet been approved. 32768
              unsigned int beta_compliance : 1;

           Internal to GPGME, do not use.  
              unsigned int _unused : 16;
         */
        public uint flags;

        /* Public key algorithm supported by this subkey.  */
        public gpgme_pubkey_algo_t pubkey_algo;

        /* Length of the subkey.  */
        public uint length;

        /* The key ID of the subkey.  */
        public IntPtr keyid; // char*

        /* Internal to GPGME, do not use.  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public byte[] _keyid;

        /* The fingerprint of the subkey in hex digit form.  */
        public IntPtr fpr; // char*

        /* The creation timestamp, -1 if invalid, 0 if not available.  */
        public IntPtr timestamp;

        /* The expiration timestamp, 0 if the subkey does not expire.  */
        public IntPtr expires;

        /* The serial number of a smart card holding this key or NULL.  */
        public IntPtr card_number; // char*

        /* The name of the curve for ECC algorithms or NULL.  */
        public IntPtr curve; // char*

        /* The keygrip of the subkey in hex digit form or NULL if not available. */
        public IntPtr keygrip; // char*

        public bool revoked
        {
            get => (flags & 1) > 0;
            set => flags = value ? flags | 1 : flags & ~1u;
        }

        public bool expired
        {
            get => (flags & 2) > 0;
            set => flags = value ? flags | 2 : flags & ~2u;
        }

        public bool disabled
        {
            get => (flags & 4) > 0;
            set => flags = value ? flags | 4 : flags & ~4u;
        }

        public bool invalid
        {
            get => (flags & 8) > 0;
            set => flags = value ? flags | 8 : flags & ~8u;
        }

        public bool can_encrypt
        {
            get => (flags & 16) > 0;
            set => flags = value ? flags | 16 : flags & ~16u;
        }

        public bool can_sign
        {
            get => (flags & 32) > 0;
            set => flags = value ? flags | 32 : flags & ~32u;
        }

        public bool can_certify
        {
            get => (flags & 64) > 0;
            set => flags = value ? flags | 64 : flags & ~64u;
        }

        public bool secret
        {
            get => (flags & 128) > 0;
            set => flags = value ? flags | 128 : flags & ~128u;
        }

        public bool can_authenticate
        {
            get => (flags & 256) > 0;
            set => flags = value ? flags | 256 : flags & ~256u;
        }

        public bool is_qualified
        {
            get => (flags & 512) > 0;
            set => flags = value ? flags | 512 : flags & ~512u;
        }

        public bool is_cardkey
        {
            get => (flags & 1024) > 0;
            set => flags = value ? flags | 1024 : flags & ~1024u;
        }

        public bool is_de_vs
        {
            get => (flags & 2048) > 0;
            set => flags = value ? flags | 2048 : flags & ~2048u;
        }

        public bool can_renc
        {
            get => (flags & 4096) > 0;
            set => flags = value ? flags | 4096 : flags & ~4096u;
        }

        public bool can_timestamp
        {
            get => (flags & 8192) > 0;
            set => flags = value ? flags | 8192 : flags & ~8192u;
        }

        public bool is_group_owned
        {
            get => (flags & 16384) > 0;
            set => flags = value ? flags | 16384 : flags & ~16384u;
        }

        public bool beta_compliance
        {
            get => (flags & 32768) > 0;
            set => flags = value ? flags | 32768 : flags & ~32768u;
        }

        public _gpgme_subkey()
        {
            _keyid = new byte[17];
        }
    }
}