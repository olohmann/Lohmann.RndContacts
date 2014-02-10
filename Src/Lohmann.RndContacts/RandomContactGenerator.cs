namespace Lohmann.RndContacts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Lohmann.RndContacts.Internal;

    public class RandomContactGenerator
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Generates a given number of random contacts.
        /// </summary>
        /// <param name="count">The number of contacts to generate. Default is 50.</param>
        /// <returns>An <see cref="IEnumerable{RandomContact}" />.</returns>
        public IEnumerable<RandomContact> GenerateRandomContacts(int count = 50)
        {
            for (int i = 0; i < count; i++)
            {
                bool isMaleContact = _random.NextDouble() > 0.50;

                string firstName = isMaleContact
                    ? DrawRandom(NamePool.MaleFirstNamePool)
                    : DrawRandom(NamePool.FemaleFirstNamePool);

                string lastName = DrawRandom(NamePool.LastNamePool);

                string company = DrawRandom(NamePool.CompanyNamePool);

                Gender gender = isMaleContact ? Gender.Male : Gender.Female;

                string email = GenerateRandomEMailAddress(firstName, lastName, company);

                yield return new RandomContact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Company = company,
                    EMailAddress = email,
                    Gender = gender
                };
            }
        }

        private string GenerateRandomEMailAddress(string firstName, string lastName, string company)
        {
            string companyTopLevelDomain = string.Format("{0}.com", company);
            string emailAddress = string.Format("{0}.{1}@{2}", firstName, lastName, companyTopLevelDomain);

            return emailAddress.ToLower();
        }

        private string DrawRandom(ReadOnlyCollection<string> src)
        {
            int randomIndex = _random.Next(0, src.Count);
            return src[randomIndex];
        }
    }
}