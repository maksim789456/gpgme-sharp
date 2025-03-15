using System;
using System.Runtime.InteropServices;

namespace Libgpgme.Interop
{
    /* A key from the keyring.  */

    [StructLayout(LayoutKind.Sequential)]
    internal class _gpgme_key //gpgme_key_t
    {
        /* Internal to GPGME, do not use.  */
        public uint _refs;

        /* True if key is revoked.  1
        uint revoked : 1;
           True if key is expired.  2
        uint expired : 1;
           True if key is disabled.  4
        uint disabled : 1;
           True if key is invalid.  8
        uint invalid : 1;
           True if key can be used for encryption.  16
        uint can_encrypt : 1;
           True if key can be used for signing.  32
        uint can_sign : 1;
           True if key can be used for certification.  64
        uint can_certify : 1;
           True if key is secret.  128
        uint secret : 1;
           True if key can be used for authentication.  256
        uint can_authenticate : 1;
           True if subkey is qualified for signatures according to German law.  512
        uint is_qualified : 1;
           This is true if the key or one of its subkeys is capable of encryption. 1024
        uint has_encrypt : 1;
           This is true if the key or one of its subkeys is capable of signing. 2048
        uint has_sign : 1;
           This is true if the key or one of its subkeys is capable of certification. 4096
        uint has_certify : 1;
           This is true if the key or one of its subkeys is capable of authentication. 8192
        uint has_authenticate : 1;
           Internal to GPGME, do not use.
        uint _unused : 13;
           Origin of this key. 0xf8000000
        uint origin : 5;*/

        public uint flags;

        /* This is the protocol supported by this key.  */
        public gpgme_protocol_t protocol;

        /* If protocol is GPGME_PROTOCOL_CMS, this string contains the
           issuer serial.  */
        public IntPtr issuer_serial; // char*

        /* If protocol is GPGME_PROTOCOL_CMS, this string contains the
           issuer name.  */
        public IntPtr issuer_name; // char *

        /* If protocol is GPGME_PROTOCOL_CMS, this string contains the chain
           ID.  */
        public IntPtr chain_id; // char *

        /* If protocol is GPGME_PROTOCOL_OpenPGP, this field contains the
           owner trust.  */
        public gpgme_validity_t owner_trust;

        /* The subkeys of the key.  */
        public IntPtr subkeys; // gpgme_subkey_t

        /* The user IDs of the key.  */
        public IntPtr uids; // gpgme_user_id_t

        /* Internal to GPGME, do not use.  */
        public IntPtr _last_subkey; //gpgme_subkey_t

        /* Internal to GPGME, do not use.  */
        public IntPtr _last_uid; //gpgme_user_id_t

        /* The keylist mode that was active when listing the key.  */
        public gpgme_keylist_mode_t keylist_mode;

        internal _gpgme_key()
        {
            _refs = 0;
            flags = 0;
            protocol = gpgme_protocol_t.GPGME_PROTOCOL_UNKNOWN;
            issuer_serial = IntPtr.Zero;
            issuer_name = IntPtr.Zero;
            chain_id = IntPtr.Zero;
            owner_trust = gpgme_validity_t.GPGME_VALIDITY_UNKNOWN;
            subkeys = IntPtr.Zero;
            uids = IntPtr.Zero;
            _last_subkey = IntPtr.Zero;
            _last_uid = IntPtr.Zero;
            keylist_mode = gpgme_keylist_mode_t.GPGME_KEYLIST_MODE_LOCAL;
        }

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

        public bool has_encrypt
        {
            get => (flags & 1024) > 0;
            set => flags = value ? flags | 1024 : flags & ~1024u;
        }

        public bool has_sign
        {
            get => (flags & 2048) > 0;
            set => flags = value ? flags | 2048 : flags & ~2048u;
        }

        public bool has_certify
        {
            get => (flags & 4096) > 0;
            set => flags = value ? flags | 4096 : flags & ~4096u;
        }

        public bool has_authenticate
        {
            get => (flags & 8192) > 0;
            set => flags = value ? flags | 8192 : flags & ~8192u;
        }

        public uint Origin
        {
            get => (flags & 0xf8000000) >> 27;
            set => flags = (flags & ~0xf8000000) | (value << 27);
        }
    }
}