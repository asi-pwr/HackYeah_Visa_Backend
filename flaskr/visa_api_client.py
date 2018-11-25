from subprocess import check_output


def push_fund_transactions():
    cmd = ['/home/jakdor/DEV/python/HackYeah_Visa_Backend/visaclient/publish/Vdp.Con', 'pull']
    out = check_output(cmd)
    return out


def pull_fund_transactions():
    cmd = ['/home/jakdor/DEV/python/HackYeah_Visa_Backend/visaclient/publish/Vdp.Con', 'push']
    out = check_output(cmd)
    return out
