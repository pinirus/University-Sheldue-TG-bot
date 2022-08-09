﻿using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace LibraryTesting.RepositoryOperationTesting.CoupleRepository;

[TestFixture]
public class FullRepoTest : BaseRepositoryTest
{
    [Test]
    public async Task FullLoadDataSet_CorrectLoading()
    {
        var countUser = 20;

        await LoadRandomDataSet(countUser);

        Uow.Users.Read().Count().Should().Be(Generator.Users.Count);
        CollectionAssert.AreEquivalent(
            Generator.Users.Select(item => item.Id),
            Uow.Users.Read().Select(item => item.Id));

        Uow.Groups.Read().Count().Should().Be(Generator.Groups.Count);
        CollectionAssert.AreEquivalent(
            Generator.Groups.Select(item => item.Id),
            Uow.Groups.Read().Select(item => item.Id));

        Uow.Subjects.Read().Count().Should().Be(Generator.Subjects.Count);
        CollectionAssert.AreEquivalent(
            Generator.Subjects.Select(item => item.Id),
            Uow.Subjects.Read().Select(item => item.Id));

        Uow.Couples.Read().Count().Should().Be(Generator.Couples.Count);
        CollectionAssert.AreEquivalent(
            Generator.Couples.Select(item => item.Id),
            Uow.Couples.Read().Select(item => item.Id));

        Uow.Homework.Read().Count().Should().Be(Generator.Homework.Count);
        CollectionAssert.AreEquivalent(
            Generator.Homework.Select(item => item.Id),
            Uow.Homework.Read().Select(item => item.Id));

        Uow.Users.Read()
            .Include(user => user.Homework)
            .Include(user => user.UsersRoles)
            .ToList()
            .Any(item => item.Homework.Count > 0 && item.UsersRoles.Count > 0).Should().BeTrue();

        Uow.Groups.Read()
            .Include(item => item.UsersRoles)
            .Include(item => item.Subjects)
            .Include(item => item.Couples)
            .ToList()
            .Any(item => item.UsersRoles.Count > 0
                         && item.Subjects.Count > 0
                         && item.Couples.Count > 0).Should().BeTrue();
    }
}