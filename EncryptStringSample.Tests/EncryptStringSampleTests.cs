using Xunit;

namespace EncryptStringSample.Tests
{
    public class EncryptStringSampleTests
    {
        [Fact]
        public void CanEncryptAndDecryptSampleStringCorrectly()
        {
            // Arrange
            var plainText = "This is my sample plain text message";
            var passPhrase = "supersecretpassword";

            // Act
            var cipherText = StringCipher.Encrypt(plainText, passPhrase);
            var decryptedText = StringCipher.Decrypt(cipherText, passPhrase);

            // Assert
            Assert.Equal(plainText, decryptedText);
        }

        [Fact]
        public void EncryptingTheSamePlainTextWithTheSamePasswordMultipleTimesProducesDifferentCipherText()
        {
            // Arrange
            var plainText = "This is my sample plain text message";
            var passPhrase = "supersecretpassword";

            // Act
            var cipherText1 = StringCipher.Encrypt(plainText, passPhrase);
            var cipherText2 = StringCipher.Encrypt(plainText, passPhrase);

            // Assert
            Assert.NotEqual(cipherText1, cipherText2);
        }

        [Fact]
        public void EncryptingTheSamePlainTextWithTheSamePasswordMultipleTimesProducesDifferentCipherTextButBothCanBeDecryptedCorrectly()
        {
            // Arrange
            var plainText = "This is my sample plain text message";
            var passPhrase = "supersecretpassword";

            // Act
            var cipherText1 = StringCipher.Encrypt(plainText, passPhrase);
            var cipherText2 = StringCipher.Encrypt(plainText, passPhrase);
            var decryptedText1 = StringCipher.Decrypt(cipherText1, passPhrase);
            var decryptedText2 = StringCipher.Decrypt(cipherText2, passPhrase);

            // Assert
            Assert.Equal(decryptedText1, plainText);
            Assert.Equal(decryptedText1, decryptedText2);

        }
    }
}
